using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Ideal Blood Pressure")] Ideal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")] High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value must be between 70 and 190")]
        public int Systolic { get; set; } // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value must be between 40 and 100")]
        public int Diastolic { get; set; } // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                // Check for invalid systolic and diastolic values and throw an exception if invalid
                if (Systolic < SystolicMin || Systolic > SystolicMax)
                    throw new ArgumentOutOfRangeException(nameof(Systolic), $"Systolic value must be between {SystolicMin} and {SystolicMax}.");
                if (Diastolic < DiastolicMin || Diastolic > DiastolicMax)
                    throw new ArgumentOutOfRangeException(nameof(Diastolic), $"Diastolic value must be between {DiastolicMin} and {DiastolicMax}.");

                // 1. High BP: Systolic ≥ 140 OR Diastolic ≥ 90
                if (Systolic >= 140 || Diastolic >= 90)
                    return BPCategory.High;

                // 2. Pre-High: Systolic 120-139 OR Diastolic 80-89
                if ((Systolic >= 120 && Systolic <= 139) || (Diastolic >= 80 && Diastolic <= 89))
                    return BPCategory.PreHigh;

                // 3. Ideal: Systolic 90-119 AND Diastolic 60-79
                if (Systolic >= 90 && Systolic <= 119 && Diastolic >= 60 && Diastolic <= 79)
                    return BPCategory.Ideal;

                // 4. Low: Everything else (Systolic < 90 OR Diastolic < 60)
                return BPCategory.Low;
            }
        }
    }
}
