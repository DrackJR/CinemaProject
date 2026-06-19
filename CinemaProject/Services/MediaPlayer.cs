using System;
using System.Windows.Forms;

namespace CinemaProject.Services
{
    public class MediaPlayer
    {
        private Timer player_;
        private int _seconds;
        private string _currentFile = string.Empty;

        public event Action<int> PositionChanged;

        public void LoadMovie(string filePath)
        {
            _currentFile = filePath;
            _seconds = 0;
            player_ = new Timer();
            player_.Interval = 1000;
            player_.Tick += (s, e) =>
            {
                _seconds++;
                if (PositionChanged != null) PositionChanged(_seconds);
            };
        }

        public void Play() { if (player_ != null) player_.Start(); }
        public void Pause() { if (player_ != null) player_.Stop(); }
        public void Stop() { if (player_ != null) { player_.Stop(); _seconds = 0; if (PositionChanged != null) PositionChanged(0); } }
        public void Seek(int seconds) { _seconds = seconds; if (PositionChanged != null) PositionChanged(_seconds); }
        public void SetVolume(int volume) { }
        public TimeSpan GetCurrentPosition() { return TimeSpan.FromSeconds(_seconds); }
    }
}