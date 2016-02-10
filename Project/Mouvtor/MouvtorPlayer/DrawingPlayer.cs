using MouvtorCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MouvtorPlayer
{
    class DrawingPlayer
    {
        class DrawingAction
        {
            public long Timestamp { get; set; }
            public Action Action { get; set; }
        }

        private DrawingZone DrawingZone { get; set; }
        private List<Path> Drawing { get; set; }
        private List<DrawingAction> DrawingActions { get; set; }
        private Stopwatch Stopwatch { get; set; }
        private Timer Timer { get; set; }

        public event Action DrawingEnded;

        public DrawingPlayer(List<Path> drawing, DrawingZone drawingZone)
        {
            Drawing = drawing;
            DrawingZone = drawingZone;

            MakeDrawingActions();
        }

        private void MakeDrawingActions()
        {
            DrawingActions = new List<DrawingAction>();
            foreach (var path in Drawing)
            {
                // Add action to start drawing the path
                DrawingActions.Add(new DrawingAction() {
                    Timestamp = path.Timestamp,
                    Action = () => { DrawingZone.StartDrawing(); }
                });

                foreach (var pathStep in path)
                {
                    // Add action to draw the step point
                    DrawingActions.Add(new DrawingAction() {
                        Timestamp = path.Timestamp + pathStep.Timestamp,
                        Action = () => { 
                            DrawingZone.AddPointDrawing(pathStep.NormalizedPosition);
                            DrawingZone.Refresh();
                        }
                    });
                }

                // Add action to end the drawing
                DrawingActions.Add(new DrawingAction()
                {
                    Timestamp = DrawingActions.Last().Timestamp,
                    Action = () => { DrawingZone.StopDrawing(); }
                });
            }
        }

        public void Play()
        {
            Stopwatch = new Stopwatch();
            Timer = new Timer() { 
                Interval = 1,
                AutoReset = true,
                SynchronizingObject = DrawingZone
            };
            var currentActionIndex = 0;

            Timer.Elapsed += (sender, eventArgs) =>
            {
                if (currentActionIndex < DrawingActions.Count)
                {
                    var currentAction = DrawingActions[currentActionIndex];
                    if (currentAction.Timestamp <= Stopwatch.ElapsedMilliseconds)
                    {
                        currentAction.Action();
                        currentActionIndex++;
                    }
                }
                else
                {
                    Timer.Stop();
                    Stopwatch.Stop();
                    DrawingEnded();
                }
            };

            Stopwatch.Start();
            Timer.Start();
        }
    }
}
