namespace OpenAI_TTS
{
    public class InputBody
    {
        public string Model { get; set; }
        public string Input { get; set; }
        public string Voice { get; set; }
        public decimal Speed { get; set; }
    }
}