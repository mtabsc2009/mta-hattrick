using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.CommonModel
{
    [SerializableAttribute]
    public enum PaneltyCard
    {
        ptNone = 1,
        ptYellow = 2,
        ptRed = 3
    }
    [SerializableAttribute]
    public abstract class GameEvent
    {
        public int Minute;
        public Team teamAttacking = null;
        public Player Actor;
        public GameEvent(Team teamSubject, int nMinute, Player plrActor)
        {
            teamAttacking = teamSubject;
            Minute = nMinute;
            Actor = plrActor;
        }
    }

    [SerializableAttribute]
    public class ScoreEvent : GameEvent
    {
        public bool bShowInSummary = true;
        public ScoreEvent(Team teamScorer, int nMinute, bool bShowInSummary, Player plrActor) : 
            base(teamScorer, bShowInSummary ? nMinute : -nMinute, plrActor)
        {
            this.bShowInSummary = bShowInSummary;
        }

        public override string ToString()
        {
            return string.Format("GOAL!! {1} from {0} Scored a goal!", teamAttacking.Name, Actor.Name);
        }
    }

    [SerializableAttribute]
    public abstract class FailedEvent : GameEvent
    {
        public FailedEvent(Team teamSubject, int nMinute, Player plrActor) : base(teamSubject, nMinute, plrActor)
        {

        }
    }

    [SerializableAttribute]
    public abstract class FouledEvent : GameEvent
    {
        public Player Foulist;
        public FouledEvent(Team teamSubject, int nMinute, Player plrAttacker,Player plrFoulist)
            : base(teamSubject, nMinute, plrAttacker)
        {
            Foulist = plrFoulist;
        }
        public PaneltyCard ptCard = PaneltyCard.ptNone;
        public Team bScored = null;
    }

    [SerializableAttribute]
    public class FreeKickEvent : FouledEvent
    {
        public Player Shooter;
        public FreeKickEvent(Team teamAttacker, int nMinute, Player plrAttacker, Player plrFoulist, Player plrShooter)
            : base(teamAttacker, nMinute, plrAttacker, plrFoulist)
        {
            Shooter = plrShooter;
        }

        public override string ToString()
        {
            string strMain = string.Format("{0}'s attack lead by {1} was stopped by a foul outside the 16 meteres! followed by a free kick", 
                teamAttacking.Name, Actor.Name);
            string strCard = string.Empty;
            if (ptCard == PaneltyCard.ptNone) strCard = string.Format("No card was shown to the defender ({0})", Foulist.Name);
            else string.Format("A {0} card was shown to the {1} (defender)", 
                ptCard == PaneltyCard.ptRed ? "Red" : "Yellow",
                Foulist.Name);
            string strScore = string.Format("{0} took the shot and {1}", 
                Shooter.Name,
                    bScored != null ? "SCORED!" : "MISSED it!");
            return string.Format("{0} {1} {2} {1} {3}", strMain, Environment.NewLine, strCard, strScore);
        }
    }

    [SerializableAttribute]
    public class PaneltyEvent : FouledEvent
    {
        public Player Shooter;
        public PaneltyEvent(Team teamSubject, int nMinute, Player plrActor, Player plrFoulist, Player plrShooter) : base(teamSubject, nMinute, plrActor, plrFoulist)
        {
            Shooter = plrShooter;
        }

        public override string ToString()
        {
            string strMain = string.Format(
                "{0}'s attack lead by {1} was stopped by a foul within the 16 meteres!{2}Taking {3} to the 11 meters spot.", 
                teamAttacking.Name, Actor.Name, Environment.NewLine, Shooter.Name);
            string strCard = string.Format("A {0} card was shown to the {1} (defender)", 
                ptCard == PaneltyCard.ptRed ? "Red" : "Yellow",
                Foulist.Name);
            string strScore =  
                string.Format("{0} took the shot {1}", Shooter.Name,
                bScored != null? "and SCORED!" : "but MISSED!");
            return string.Format("{0} {1} {2} {1} {3}", strMain, Environment.NewLine, strCard, strScore);
        }
    }

    [SerializableAttribute]
    public class MissedFouledEvent : FouledEvent
    {
        public MissedFouledEvent(Team teamSubject, int nMinute, Player plrActor, Player plrFoulist)
            : base(teamSubject, nMinute, plrActor, plrFoulist)
        {

        }

        public override string ToString()
        {
            return string.Format("The crowed shouted when the referee missed {0}'s from {1} foul on {2}!", 
                Foulist.Name, 
                teamAttacking.Name,
                Actor.Name);
        }
    }

    [SerializableAttribute]
    public class MissedEvent : FailedEvent
    {
        public MissedEvent(Team teamSubject, int nMinute, Player plrActor)
            : base(teamSubject, nMinute, plrActor)
        {

        }
        public override string ToString()
        {
            return string.Format("{0} from {1} took a long shot and missed !", Actor.Name, teamAttacking.Name);
        }
    }

    [SerializableAttribute]
    public class StoppedEvent : FailedEvent
    {
        public StoppedEvent(Team teamSubject, int nMinute, Player plrActor)
            : base(teamSubject, nMinute, plrActor)
        {

        }

        public override string ToString()
        {
            return string.Format("{0}'s from {1} attack was stopped by the defence", Actor.Name, teamAttacking.Name);
        }
    }
}
