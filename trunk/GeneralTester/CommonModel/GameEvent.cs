using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.CommonModel
{
    public enum PaneltyCard
    {
        ptNone = 1,
        ptYellow = 2,
        ptRed = 3
    }
    public abstract class GameEvent
    {
        public Team teamAttacking = null;
        public GameEvent(Team teamSubject)
        {
            teamAttacking = teamSubject;
        }
    }

    public class ScoreEvent : GameEvent
    {
        public bool bShowInSummary = true;
        public ScoreEvent(Team teamScorer, bool bShowInSummary) : base(teamScorer)
        {
            this.bShowInSummary = bShowInSummary;
        }

        public override string ToString()
        {
            return string.Format("GOAL!! {0} Scored a goal!", teamAttacking.Name);
        }
    }

    public abstract class FailedEvent : GameEvent
    {
        public FailedEvent(Team teamSubject) : base(teamSubject)
        {

        }
    }

    public abstract class FouledEvent : GameEvent
    {
        public FouledEvent(Team teamSubject) : base(teamSubject)
        {

        }
        public PaneltyCard ptCard = PaneltyCard.ptNone;
        public Team bScored = null;
    }

    public class FreeKickEvent : FouledEvent
    {
        public FreeKickEvent(Team teamAttacker) : base(teamAttacker)
        {
        }

        public override string ToString()
        {
            string strMain = string.Format("{0}'s attack was stopped by a foul outside the 16 meteres! followed by a free kick", teamAttacking.Name);
            string strCard = string.Empty;
            if (ptCard == PaneltyCard.ptNone) strCard = "No card was shown to the defender";
            else string.Format("A {0} card was shown to the defender", ptCard == PaneltyCard.ptRed ? "Red" : "Yellow");
            string strScore = bScored != null ?
                string.Format("The main shooter SCORED!") :
                string.Format("But the main shooter MISSED the shot!");
            return string.Format("{0} {1} {2} {1} {3}", strMain, Environment.NewLine, strCard, strScore);
        }
    }

    public class PaneltyEvent : FouledEvent
    {
        public PaneltyEvent(Team teamSubject) : base(teamSubject)
        {

        }

        public override string ToString()
        {
            string strMain = string.Format("{0}'s attack was stopped by a foul within the 16 meteres! taking the main shooter to the 11 meters spot.", teamAttacking.Name);
            string strCard = string.Format("A {0} card was shown to the defender", ptCard == PaneltyCard.ptRed ? "Red" : "Yellow");
            string strScore = bScored != null? 
                string.Format("The main shooter SCORED!") :
                string.Format("But the main shooter MISSED the shot!") ;
            return string.Format("{0} {1} {2} {1} {3}", strMain, Environment.NewLine, strCard, strScore);
        }
    }

    public class MissedFouledEvent : FouledEvent
    {
        public MissedFouledEvent (Team teamSubject) : base(teamSubject)
        {

        }

        public override string ToString()
        {
            return string.Format("The crowed shouted when the referee missed the foul on {0}!", teamAttacking.Name);
        }
    }

    public class MissedEvent : FailedEvent
    {
        public MissedEvent(Team teamSubject) : base(teamSubject)
        {

        }
        public override string ToString()
        {
            return string.Format("{0}'s missed the shot !", teamAttacking.Name);
        }
    }

    public class StoppedEvent : FailedEvent
    {
        public StoppedEvent(Team teamSubject) : base(teamSubject)
        {

        }

        public override string ToString()
        {
            return string.Format("{0}'s attack was stopped by the defence", teamAttacking.Name);
        }
    }
}
