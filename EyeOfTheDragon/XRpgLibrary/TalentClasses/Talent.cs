﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.CharacterClasses;

namespace RpgLibrary.TalentClasses
{
    public class Talent
    {
        #region Field Region

        string name;
        List<string> allowedClasses;
        Dictionary<string, int> attributeRequirements;
        List<string> talentPrerequisites;
        int levelRequirement;
        TalentType talentType;
        int activationCost;
        List<string> effects;
        
        #endregion

        #region Property Region

        public string Name
        {
            get { return name; }
        }

        public List<string> AllowedClasses
        {
            get { return allowedClasses; }
        }

        public Dictionary<string, int> AttributeRequirements
        {
            get { return attributeRequirements; }
        }

        public List<string> TalentPrerequisites
        {
            get { return talentPrerequisites; }
        }

        public int LevelRequirement
        {
            get { return levelRequirement; }
        }

        public TalentType TalentType
        {
            get { return talentType; }
        }

        public int ActivationCost
        {
            get { return activationCost; }
        }

        public List<string> Effects
        {
            get { return effects; }
        }

        #endregion

        #region Constructor Region

        private Talent()
        {
            allowedClasses = new List<string>();
            attributeRequirements = new Dictionary<string, int>();
            talentPrerequisites = new List<string>();
            effects = new List<string>();
        }

        #endregion

        #region Method Region

        public static Talent FromTalentData(TalentData data)
        {
            Talent talent = new Talent();

            talent.name = data.Name;

            foreach (string s in data.AllowedClasses)
                talent.allowedClasses.Add(s.ToLower());

            foreach (string s in data.AttributeRequirements.Keys)
                talent.attributeRequirements.Add(
                    s.ToLower(), 
                    data.AttributeRequirements[s]);

            foreach (string s in data.TalentPrerequisites)
                talent.talentPrerequisites.Add(s);

            talent.levelRequirement = data.LevelRequirement;
            talent.talentType = data.TalentType;
            talent.activationCost = data.ActivationCost;

            foreach (string s in data.Effects)
                talent.Effects.Add(s);

            return talent;
        }

        public static bool CanLearn(Entity entity, Talent talent)
        {
            bool canLearn = true;

            if (entity.Level < talent.LevelRequirement)
                canLearn = false;

            string entityClass = entity.EntityClass.ToLower();

            if (!talent.AllowedClasses.Contains(entityClass))
                canLearn = false;

            foreach (string s in talent.AttributeRequirements.Keys)
            {
                if (Mechanics.GetAttributeByString(entity, s) < talent.AttributeRequirements[s])
                {
                    canLearn = false;
                    break;
                }
            }

            foreach (string s in talent.TalentPrerequisites)
            {
                if (!entity.Talents.ContainsKey(s))
                {
                    canLearn = false;
                    break;
                }
            }

            return canLearn;
        }

        #endregion

        #region Virtual Method Region
        #endregion
    }
}
