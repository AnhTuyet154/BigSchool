namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Followings", "FollowerId");
            RenameColumn(table: "dbo.Followings", name: "Follower_Id", newName: "FollowerId");
            RenameColumn(table: "dbo.Followings", name: "ApplicationUser_Id", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Follower_Id", newName: "IX_FollowerId");
            RenameIndex(table: "dbo.Followings", name: "IX_ApplicationUser_Id", newName: "IX_FolloweeId");
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", "FollowerId");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "IX_Follower_Id");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "Follower_Id");
            AddColumn("dbo.Followings", "FollowerId", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
