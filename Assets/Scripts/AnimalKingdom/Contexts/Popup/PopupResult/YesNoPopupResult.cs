namespace PG.AnimalKingdom.Contexts.Popup.PopupResult
{
    public class YesNoPopupResult : Core.Context.PopupResult
    {

        public bool Yes
        {
            get
            {
                return SelectedIndex == 0;
            }
        }

        public bool No
        {
            get
            {
                return SelectedIndex == 1;
            }
        }
    }
}