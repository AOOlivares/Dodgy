namespace Dodgy.Application.Sprite
{
    public interface IMovement
    {
        void Up();
        void Down();
        void Left();
        void Right();
    }

    public class Movement : IMovement
    {
        public void Down()
        {
            throw new System.NotImplementedException();
        }

        public void Left()
        {
            throw new System.NotImplementedException();
        }

        public void Right()
        {
            throw new System.NotImplementedException();
        }

        public void Up()
        {
            throw new System.NotImplementedException();
        }
    }
}