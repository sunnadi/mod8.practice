using System;
using System.Collections.Generic;
public interface IMediator
{
    void SendMessage(string message, User sender);
    void AddUser(User user);
    void RemoveUser(User user);
}

public class ChatRoom : IMediator
{
    private readonly List<User> _users = new List<User>();

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.ReceiveMessage(message, sender.Name);
            }
        }
    }

    public void AddUser(User user)
    {
        _users.Add(user);
        Console.WriteLine($"{user.Name} присоединился к чату.");
    }

    public void RemoveUser(User user)
    {
        _users.Remove(user);
        Console.WriteLine($"{user.Name} покинул чат.");
    }
}

public class User
{
    public string Name { get; }
    private IMediator _mediator;

    public User(string name, IMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void SendMessage(string message)
    {
        if (_mediator == null)
        {
            Console.WriteLine($"{Name} не может отправить сообщение. Он не в чате.");
            return;
        }

        Console.WriteLine($"{Name} отправил: {message}");
        _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message, string senderName)
    {
        Console.WriteLine($"[{Name} получил от {senderName}]: {message}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var chatRoom = new ChatRoom();

        var user1 = new User("Лидия", chatRoom);
        var user2 = new User("Мария", chatRoom);
        var user3 = new User("Алиса", chatRoom);

        chatRoom.AddUser(user1);
        chatRoom.AddUser(user2);
        chatRoom.AddUser(user3);

        user1.SendMessage("Привет всем!");
        user2.SendMessage("Здравствуйте, Лидия!");
        user3.SendMessage("Как дела?");

        chatRoom.RemoveUser(user2);

        user1.SendMessage("Где Мария?");
        user3.SendMessage("Я не знаю, она покинула чат.");
    }
}
