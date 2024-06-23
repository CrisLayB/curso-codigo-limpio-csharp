List<string> TaskList = new List<string>();

int menuSelected = 0;
do 
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAddTask();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemoveTask();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

/// <summary>
/// Show the options for Task, 1. Nueva tarea , 2. Remover tarea, 3. Tareas pendientes , 4. Salir
/// </summary>
/// <returns>Returns option selected by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string menuSelected = Console.ReadLine();
    int numberMenuSelected;
    bool isNumeric = int.TryParse(menuSelected, out numberMenuSelected);

    if(!isNumeric)
    {
        Console.WriteLine("Letras no son validas");
        return Convert.ToInt32(Menu.Invalid);
    }
    
    return numberMenuSelected;
}

void ShowMenuRemoveTask()
{
    if(TaskList.Count == 0)
    {
        Console.WriteLine("No hay tareas pendientes para remover");
        return;
    }
    
    Console.WriteLine("Ingrese el número de la tarea a remover: ");
    
    ShowMenuTaskList();

    string optionSelected = Console.ReadLine();

    int taskSelected;
    bool isNumeric = int.TryParse(optionSelected, out taskSelected);

    if(!isNumeric)
    {
        Console.WriteLine("Letras no son validas");
        return;
    }
    
    // Remove one position because the array starts in 0
    int indexToRemove = taskSelected - 1;

    if(indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
    {
        Console.WriteLine("Numero de tarea seleccionado no es valido");
        return;
    }
        
    string task = TaskList[indexToRemove];
    TaskList.RemoveAt(indexToRemove);
    Console.WriteLine($"Tarea {task} eliminada");
}

void ShowMenuAddTask()
{
    Console.WriteLine("Ingrese el nombre de la tarea: ");
    string task = Console.ReadLine();

    if(task.Trim() == "")
    {
        Console.WriteLine("Nombre de tarea vacia, porfavor ingresa un nombre valido a la tarea");
        return;
    }
    
    TaskList.Add(task);
    Console.WriteLine("Tarea registrada");
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        Console.WriteLine("----------------------------------------");
        int indexTask = 0;
        TaskList.ForEach(task => Console.WriteLine($"{++indexTask}. {task}"));
        Console.WriteLine("----------------------------------------");                
        return;
    } 

    Console.WriteLine("No hay tareas por realizar");
}

public enum Menu
{
    Invalid = 0,
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4,
}