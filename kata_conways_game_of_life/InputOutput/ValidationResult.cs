namespace kata_conways_game_of_life.InputOutput
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        
        public int Dimension { get; set; }
        
        public int[] Coordinates { get; set; }
        
        public string ErrorMessage { get; set; }

        internal static ValidationResult CreateError(string errorMessage)
        {
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = errorMessage
            };
        }

        internal static ValidationResult CreateSuccess(int dimension)
        {
            return new ValidationResult
            {
                IsValid = true,
                Dimension = dimension
            };
        }

        internal static ValidationResult CreateSuccess(int[] coordinates)
        {
            return new ValidationResult
            {
                IsValid = true,
                Coordinates = coordinates
            };
        }
        
    }
}