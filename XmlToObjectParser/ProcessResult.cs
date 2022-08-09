namespace XmlToObjectParser
{
    public class ProcessResult<TResult>
    {
        public bool IsValid { get; }

        public TResult Result { get; }
        
        public ProcessResult(TResult result)
        {
            Result = result;
        }

        public ProcessResult()
        {
            IsValid = false;
        }
    }
}