using System;
using System.Linq;
using UsersGroups.data;

namespace UsersAndGroups
{
    class Program
    {
        static void Main()
        {
            UsersGroupsEntities db = new UsersGroupsEntities();
            
            using (db)
            {
                //users awready in the database. It will throw doublicate exception if you try to insert them again.
                //The same apply for the groups.
                
                //db.Groups.Add(CreateNewGroup(1, "Admins"));
                //db.Users.Add(CreateNewUser(0, 1, "Pesho"));
                //db.Users.Add(CreateNewUser(1, 1, "Kiro"));

                //User not in the database.
                db.Users.Add(CreateNewUser(1, 1, "Stamat"));
                db.SaveChanges();
            }
        }

        static Group CreateNewGroup(int id, string name)
        {
            Group newGroup = new Group();
            newGroup.id = id;
            newGroup.groupName = name;
            return newGroup;
        }

        static User CreateNewUser(int id, int groupId, string username)
        {
            User newUser = new User();
            newUser.id = id;
            newUser.username = username;
            newUser.groupId = groupId;
            return newUser;
        }
    }
}
