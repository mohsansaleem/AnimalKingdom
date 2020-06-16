namespace PG.AnimalKingdom.Contexts.Popup.PopupResult
{
    public class OkCancelPopupResult : Core.Context.PopupResult
    {
        public bool Ok
        {
            get
            {
                return SelectedIndex == 0;
            }
        }

        public bool Cancel
        {
            get
            {
                return SelectedIndex == 1;
            }
        }
    }
}