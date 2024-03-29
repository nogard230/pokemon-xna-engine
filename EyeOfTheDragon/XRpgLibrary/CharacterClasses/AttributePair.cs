﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class AttributePair
    {
        #region Field Region

        int currentValue;
        int maximumValue;

        #endregion

        #region Property Region

        /// <summary>
        /// Gets or sets the currentvalue.
        /// </summary>
        public int CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }

        /// <summary>
        /// Gets or sets the maximumvalue.
        /// </summary>
        public int MaximumValue
        {
            get { return maximumValue; }
            set { maximumValue = value; }
        }

        public static AttributePair Zero
        {
            get { return new AttributePair(); }
        }

        #endregion

        #region Constructor Region

        private AttributePair()
        {
            currentValue = 0;
            maximumValue = 0;
        }

        public AttributePair(int maxValue)
        {
            currentValue = maxValue;
            maximumValue = maxValue;
        }

        #endregion

        #region Method Region

        public void Heal(int value)
        {
            currentValue += value;
            if (currentValue > maximumValue)
                currentValue = maximumValue;
        }

        public void Damage(int value)
        {
            currentValue -= value;
            if (currentValue < 0)
                currentValue = 0;
        }

        public void SetCurrent(int value)
        {
            currentValue = value;
            if (currentValue > maximumValue)
                currentValue = maximumValue;
        }

        public void SetMaximum(int value)
        {
            maximumValue = value;
            if (currentValue > maximumValue)
                currentValue = maximumValue;
        }

        #endregion
    }
}
