using System;

namespace TPort.Domain.UserManagement
{
    public class PassportData
    {
        public PassportData(string firstName, string patronymic, string surname, Gender gender,
            DateTimeOffset birthDate, string birthPlace)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            Patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Gender = gender;
            BirthDate = birthDate;
            BirthPlace = birthPlace ?? throw new ArgumentNullException(nameof(birthPlace));
        }

        public string FirstName { get; }
        
        public string Patronymic { get; }
        
        public string Surname { get; }
        
        public Gender Gender { get; }
        
        public DateTimeOffset BirthDate { get; }
        
        public string BirthPlace { get; }
    }
}