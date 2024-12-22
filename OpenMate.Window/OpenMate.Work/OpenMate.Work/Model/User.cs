﻿using OpenMate.Work.Resources.Uitilities;

namespace OpenMate.Work.Model
{
    public class User : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        private bool _IsSelected;
        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                _IsSelected = value;
                if (_IsSelected == true)
                {
                    IsRead = true;
                    OnPropertyChanged(nameof(IsRead));
                }
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        private bool _IsRead;
        public bool IsRead
        {
            get => _IsRead;
            set => SetProperty(ref _IsRead, value);
        }
    }
}
