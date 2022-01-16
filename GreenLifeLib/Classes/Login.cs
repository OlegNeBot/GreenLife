namespace GreenLifeLib
{
    //This class is needed to take user id whenever you want and do auto-loginning
    //through the JSON-file.
    public class Login 
    { 

        #region [Props]

        public int Id { get; set; }

        public string LoginStatus { get; set; }

        #endregion

        #region [Constructors]

        public Login()
        { 
        
        }

        #endregion

    }
}
