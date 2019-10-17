using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace STAR
{
    public class ModelView
    {
        string pickupAddress = string.Empty;
        string dropAddress = string.Empty;
        string DateNTime = string.Empty;

        public string getCurrAddress
        {
            get => pickupAddress;
            set
            {
                if (pickupAddress == value)
                    return;
                pickupAddress = value;
            }
        }

        public string getDestAddress
        {
            get => dropAddress;
            set
            {
                if (dropAddress == value)
                    return;
                dropAddress = value;
            }
        }

        public string getDateNTime
        {
            get => DateNTime;
            set
            {
                if (DateNTime == value)
                    return;
                DateNTime = value;
            }
        }

        public ICommand NavigateCommand { private set; get; }
    }
}
