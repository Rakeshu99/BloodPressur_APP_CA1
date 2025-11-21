using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Ideal Blood Pressure")] Ideal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")] High
    }

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value must be between 70 and 190")]
        public int Systolic { get; set; }

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value must be between 40 and 100")]
        public int Diastolic { get; set; }

        /// <summary>
        /// Validates systolic and diastolic ranges.
        /// </summary>
        private void Validate()
        {
            if (Systolic < SystolicMin || Systolic > SystolicMax)
                throw new ArgumentOutOfRangeException(nameof(Systolic),
                    $"Systolic value must be between {SystolicMin} and {SystolicMax}.");

            if (Diastolic < DiastolicMin || Diastolic > DiastolicMax)
                throw new ArgumentOutOfRangeException(nameof(Diastolic),
                    $"Diastolic value must be between {DiastolicMin} and {DiastolicMax}.");
        }

        /// <summary>
        /// Calculates the blood pressure category.
        /// </summary>
        /// <returns>BPCategory enum value</returns>
        public BPCategory CalculateCategory()
        {
            Validate();

            // High: ≥140 OR ≥90
            if (Systolic >= 140 || Diastolic >= 90)
                return BPCategory.High;

            // Pre-High: 120–139 OR 80–89
            if (Systolic is >= 120 and <= 139 || Diastolic is >= 80 and <= 89)
                return BPCategory.PreHigh;

            // Ideal: 90–119 AND 60–79
            if (Systolic is >= 90 and <= 119 && Diastolic is >= 60 and <= 79)
                return BPCategory.Ideal;

            // Everything else = Low
            return BPCategory.Low;
        }

        // Expose as simple read-only property (Sonar-friendly)
        public BPCategory Category => CalculateCategory();
    }
}
