namespace AligatorApi.Models
{
    public class PersonBill
    {
        public PersonBill()
        {

        }
        public PersonBill(Person person, Bill bill)
        {
            Bill = bill;
            BillId = bill.Id;
            bill.PersonBills.Add(this);

            Person = person;
            PersonId = person.Id;
            person.PersonBills.Add(this);
        }

        //Learned that this is needed, although this is a DRY violation
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
