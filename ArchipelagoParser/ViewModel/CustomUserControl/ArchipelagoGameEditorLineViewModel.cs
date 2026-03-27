using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl
{
    public enum GameStateEnum
    {
        InProgress,
        Finished,
        Released,
        Aborted
    }
    public enum ReleaseReasonEnum
    {
        Generation,
        GameBug,
        Setup,
        SkillIssue,
        Version,
        Life
    }
    class ArchipelagoGameEditorLineViewModel : NotifyableViewModel
    {
        public int ArchipelId
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public int GameId
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string? PlayerName
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string? GameName
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public GameStateEnum GameState
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public int CheckAmount
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public ReleaseReasonEnum ReleaseReason
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }

    }
}
