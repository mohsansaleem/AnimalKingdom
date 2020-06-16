namespace PG.AnimalKingdom.Contexts.Popup.PopupResult
{
    public class MessagePopupResult : Core.Context.PopupResult
    {
        public bool Ok
        {
            get
            {
                return SelectedIndex == 0;
            }
        }
    }
}