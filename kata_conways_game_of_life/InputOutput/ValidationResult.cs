namespace kata_conways_game_of_life.InputOutput
{
    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        public int Dimension { get; private set; }
        public int[] Coordinates { get; private set; }
        public string ErrorMessage { get; private set; }

        internal static ValidationResult Error(string errorMessage)
        {
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = errorMessage
            };
        }

        internal static ValidationResult Success(int dimension)
        {
            return new ValidationResult
            {
                IsValid = true,
                Dimension = dimension
            };
        }

        internal static ValidationResult Success(int[] coordinates)
        {
            return new ValidationResult
            {
                IsValid = true,
                Coordinates = coordinates
            };
        }
        
    }
}