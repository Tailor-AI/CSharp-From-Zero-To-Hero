using BootCamp.Chapter.Interface;
using System;

namespace BootCamp.Chapter.Teachers
{
    public class UniversityTeacher : ITeacher<ISubject>
    {
        private readonly ISubject subject;

        public UniversityTeacher(ISubject _subject)
        {
            subject = _subject;
        }

        public ISubject ProduceMaterial()
        {
            return subject;
        }

        public override string ToString()
        {
            return string.Format($"{subject} universityteacher");
        }
    }
}
