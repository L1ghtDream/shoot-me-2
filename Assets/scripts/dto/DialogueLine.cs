namespace dto{
    public class DialogueLine{
        public string message;
        public DialogueLine nextDialogue;

        public DialogueLine(string message, DialogueLine nextDialogue){
            this.message = message;
            this.nextDialogue = nextDialogue;
        }
        
        public DialogueLine(string message){
            this.message= message;
        }
        
        
    }
}