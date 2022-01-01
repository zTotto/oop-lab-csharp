using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly Dictionary<string, ISet<TUser>> _followedUsers = new Dictionary<string, ISet<TUser>>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (_followedUsers.ContainsKey(group))
            {
                if (_followedUsers[group].Contains(user)) {
                    return false;
                } else
                {
                    _followedUsers[group].Add(user);
                    return true;
                }
            }
            else
            {
                var users = new HashSet<TUser>();
                users.Add(user);
                _followedUsers[group] = users;
                return true;
            }
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                IList<TUser> followedUsers = new List<TUser>();
                foreach (var group in _followedUsers.Keys)
                {
                    foreach (var user in _followedUsers[group])
                    {
                        followedUsers.Add(user);
                    }
                }
                return followedUsers;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if (group != null && _followedUsers.ContainsKey(group))
            {
                return new HashSet<TUser>(_followedUsers[group]);
            }
            else return new HashSet<TUser>();
        }
    }
}
