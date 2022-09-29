namespace apiNet.Models
{
    public class Tasks
    {
        public int pk_task_id { get; set; }
        public string task_detail { get; set; }
        public int fk_user_id { get; set; }
    }

    public class Users
    {
        public int pk_user_id { get; set; }
        public string name { get; set; }
    }
        
    public class UsersWithTaks : Users
    {
        public List<Task> tasks { get; set; }
    }
}
