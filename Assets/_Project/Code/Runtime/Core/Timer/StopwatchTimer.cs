﻿namespace _Project.Code.Runtime.Core.Timer
{
    public class StopwatchTimer : BaseTimer
    {
        public StopwatchTimer() : base(0)
        {
        }

        protected override void Tick(float deltaTime)
        {
            if (IsRunning)
                Time += deltaTime;
        }

        public void Reset() => Time = 0;

        public float GetTime() => Time;
    }
}