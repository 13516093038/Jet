using System.Threading;
using Core.UpdateSystem;
using Cysharp.Threading.Tasks;

namespace Runtime.UpdateSystem.UniTaskUpdate
{
    /// <summary>
    /// UniTask轮询系统
    /// </summary>
    public class UniTaskUpdateSystem : UpDateSystemBase
    {
        private CancellationTokenSource _cancellationTokenSource;
        
        public override void Run()
        {
            _cancellationTokenSource  = new CancellationTokenSource();
            if (IsRunning)
            {
                return;
            }
            else
            {
                IsRunning = true;
            }

            StartUpDate().Forget();
        }

        public override void StopRun()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            IsRunning = false;
        }

        private async UniTaskVoid StartUpDate()
        {
            while (IsRunning)
            {
                Update();
                await UniTask.Yield(cancellationToken: _cancellationTokenSource.Token);
            }
        }

        ~UniTaskUpdateSystem()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}