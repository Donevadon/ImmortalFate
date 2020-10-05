using UnityEngine;
namespace Assets.DialogModule
{
    public partial class DialogManager : MonoBehaviour
    {
        /// <summary>
        /// Сцены диалогов
        /// </summary>
        public enum Scenes
        {
            Intro,
            FirstDayStreetMorning,
            FirstDayStreetEvening,
            FirstDayOffice,
            SecondDayOffice,
            SecondDayStreetMorning,
            SecondDayHome,
            SecondDayStreetEvening,
            ThirdDayHome,
            ThirdDayStreetMorning,
            ThirdDayOffice,
            FourthDayHome,
            FourthDayStreetMorning,
            FourthDayOffice,
            FourthDayStreetEvening,
            ThirdDayStreetEvening,
            Outro
        }
        /// <summary>
        /// Места диалогов на сценах
        /// </summary>
        public enum Places
        {
            EdWakeUp,
            ClickOnTable,
            ClickOnPoster,
            ClickOnAwards,
            ClickOnPhotos,
            ClickOnBallOnFloor,
            ThouhtsAfterTakeBall,
            ClickOnBall,
            ClickOnDoor,
            SolveDoorPuzzle,
            EdWalkUpAri,
            PeopleTalkFirst,
            PeopleTalkSecond,
            ClickOnSecurity,
            ClickOnAlice,
            ClickOnMark,
            ClickOnChris,
            ClickOnBob,
            OpenPrinterPanel,
            ClosePrinterPanel,
            GearsHintFirst,
            GearsHintSecond,
            GearsHintThird,
            GearsHintFourth,
            SolveGears,
            EdWalkUpDavid,
            ClickOnDavid,
            TalkAboutTom,
            TornPaperHint,
            FindTornPaper,
            DocumentationHint,
            DocumentationOnWorkspace,
            ClickOnDavidAfterSolveServer,
            ClickOnWorkspace,
            SolveWorkPuzzle,
            ThouhtsAfterTakeBookFirst,
            ThouhtsAfterTakeBookSecond,
            ThouhtsAfterTakeBookThird,
            ThouhtsAfterTakeBookFourth,
            EdWalkUpAriFirst,
            EdWalkUpAriSecond,
            EdWalkUpAriThird,
            EdAriWalkUpEdHome,
            GiveBookAri,
            ThoughtsAfterLeaveHomeFirst,
            ThoughtsAfterLeaveHomeSecond,
            ThoughtsAfterLeaveHomeThird,
            ClickOnMarkBeforeSolveLockPuzzle,
            ClickOnLock,
            HairpinHint,
            ClickOnHairpin,
            HairpinBreak,
            ClickOnLockAfterHairpinBreak,
            SolveLockPuzzle,
            ClickOnMarkAfterSolveLockPuzzle,
            EdWalkUpSecurity,
            EdWalkUpDoor,
            BobGivePrinterQuest,
            EdWalkUpPeople,
            SolveDreamPuzzle,
            ThoughtsAfterLeaveOffice,
            DontGiveBookAri,
            HeroesLeaveOfficeFirst,
            HeroesLeaveOfficeSecond,
            ClickOnHomeDoor,
            EdTellAboutLife
        }
    }
}