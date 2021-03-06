﻿using System.Collections.Generic;
using Acceleratio.SPDG.Generator.SPModel;
using Microsoft.SharePoint.Client;

namespace Acceleratio.SPDG.Generator.Client.SPModel
{
    class SPDGClientGroup : SPDGGroup
    {
        private readonly Group _group;
        private readonly ClientContext _context;

        public SPDGClientGroup(Group group, ClientContext context) : base(group.Id, group.LoginName, group.LoginName)
        {
            _group = @group;
            _context = context;
        }

        public Group Group
        {
            get { return _group; }
        }

        public override void AddUsers(IEnumerable<SPDGUser> users)
        {
            foreach (SPDGClientUser spdgUser in users)
            {
                _group.Users.AddUser(spdgUser.User);
            }
            _context.ExecuteQuery();
         
        }
    }
}
