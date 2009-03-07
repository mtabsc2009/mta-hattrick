using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.CommonModel
{
    public static class Consts
    {
        private static Random rndGameRandom = new Random();

        public static Random GameRandom
        {
            get { return Consts.rndGameRandom; }
        }


        public enum PlayerSkillsTypes
        {
            KEEPER = 0,
            DEFENDING,
            PLAYMAKING,
            WINGER,
            PASSING,
            SCORING,
            SETPIECES
        }

        public enum PlayerAbilities
        {
            NON_EXISTENT = 0,
            DISASTROUS,
            WRETCHED,
            POOR,
            WEAK,
            INADEQUATE,
            PASSABLE,
            SOLID,
            EXCELLENT,
            FORMIDABLE,
            OUTSTANDING,
            BRILLIANT,
            MAGNIFICENT,
            WORLD_CLASS,
            SUPERNATURAL,
            TITANIC,
            EXTRATERRESTRIAL,
            MYTHICAL,
            MAGICAL,
            UTOPIAN,
            DIVINE
        }
    }
}
