namespace AligatorApi.Models
{
    public class PersonTask
    {
        public PersonTask()
        {

        }
        public PersonTask(Person person, Task task)
        {
            Person = person;
            PersonId = person.Id;
            person.PersonTasks.Add(this);

            Task = task;
            TaskId = task.Id;
            task.PersonTasks.Add(this);
        }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
