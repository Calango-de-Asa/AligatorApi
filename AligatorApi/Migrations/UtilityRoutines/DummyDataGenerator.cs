using AligatorApi.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Linq;

namespace AligatorApi.Migrations.UtilityRoutines
{
    public abstract class DummyDataGenerator
    {
        public static void Gen(MigrationBuilder mb)
        {
            var house = new House(0);

            mb.InsertData(
                table: "House",
                columns: new[] { "Id" },
                values: new object[] { house.Id });

            var p1 = new Person(0, "Fulano de Tal", "fulano@exemplo.com", false);
            var p2 = new Person(1, "Cicrano de Tal", "cicrano@exemplo.com", false);
            var p3 = new Person(2, "Beltrano de Tal", "Beltrano@exemplo.com", false);


            p1.NoticeCreate("Please stop washing underwear on the sink");
            p2.NoticeCreate("We are out of beer");
            p3.NoticeCreate("Our table is broken");

            house.AddPerson(p1);
            house.AddPerson(p2);
            house.AddPerson(p3);

            createPerson(mb, p1);
            createPerson(mb, p2);
            createPerson(mb, p3);

            var bill = new Bill(
                id: 0,
                name: "Pizza",
                description: "That pizza fulano asked for",
                dueTime: DateTime.Today,
                person: p1);

            createBill(mb, bill);

            var task = new Task(
                id: 0,
                name: "Clear the floor",
                description: "Clean out the coffee out of the kitchen floor",
                dueTime: DateTime.Today, people: new[] { p1, p2, p3 }
                );

            createTask(mb, task);

        }

        private static void createPerson(MigrationBuilder mb, Person p)
        {
            mb.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "Email", "IsManager", "HouseId" },
                values: new object[] { p.Id, p.Name, p.Email, p.IsManager, p.House.Id }
                );

            foreach (Notice notice in p.Notices)
            {
                mb.InsertData(
                    table: "Notices",
                    columns: new[] { "PersonId", "Body", "CreatedAt" },
                    values: new object[] { p.Id, notice.Body, notice.CreatedAt }
                    );
            }
        }

        private static void createBill(MigrationBuilder mb, Bill bill)
        {
            mb.InsertData(
               table: "Bills",
               columns: new[] { "Id", "Name", "Description", "CreatedAt", "DueTime", "IsPaid" },
               values: new object[] { bill.Id, bill.Name, bill.Description, bill.DueTime, bill.CreatedAt, bill.IsPaid }
               );

             for (int i = 0; i < bill.PersonBills.Count; ++i)
             {
                 mb.InsertData(
                     table: "PersonBills",
                     columns: new[] { "PersonId", "BillId" },
                     values: new object[] { bill.Id, bill.PersonBills.ToList()[i].PersonId });
             }
        }

        private static void createTask(MigrationBuilder mb, Task task)
        {
            mb.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Name", "Description", "CreatedAt", "DueTime", "Done" },
                values: new object[] { task.Id, task.Name, task.Description, task.CreatedAt, task.DueTime, task.Done });

            for (int i = 0; i < task.PersonTasks.Count; ++i)
            {
                mb.InsertData(
                    table: "PersonTasks",
                    columns: new[] { "PersonId", "TaskId" },
                    values: new object[] { task.PersonTasks.ToList()[i].PersonId, task.Id });
            }
        }
    }
}
