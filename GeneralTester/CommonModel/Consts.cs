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

        public static readonly float[] fTrainPeroid = { 0.5F, 0.7F, 1, 1.5F, 2, 2.5F, 2.7F, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        public static readonly int nTrainsPerMonth = 28;

        //public enum PlayerAbilities
        //{
        //    NON_EXISTENT = 0,
        //    DISASTROUS,
        //    WRETCHED,
        //    POOR,
        //    WEAK,
        //    INADEQUATE,
        //    PASSABLE,
        //    SOLID,
        //    EXCELLENT,
        //    FORMIDABLE,
        //    OUTSTANDING,
        //    BRILLIANT,
        //    MAGNIFICENT,
        //    WORLD_CLASS,
        //    SUPERNATURAL,
        //    TITANIC,
        //    EXTRATERRESTRIAL,
        //    MYTHICAL,
        //    MAGICAL,
        //    UTOPIAN,
        //    DIVINE
        //}

        public enum TrainingType
        {
            ATTACK = 1,
            DEFENCE,
            WING,
            PLAYMAKING,
            SETPIECES
        }
    }
}
