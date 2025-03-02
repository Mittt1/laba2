open System

// Функция для ввода целого числа с проверкой
let rec vvod_s_proverkoy (stroka: string) : int =
    printf "%s" stroka
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | true, value -> value
    | false, _ -> 
        printfn "Ошибка! Введите целое число."
        vvod_s_proverkoy stroka

// Функция для ввода строки
let VYVSTR (stroka: string) : string =
    printf "%s" stroka
    Console.ReadLine()

// Функция для генерации списка строк с вводом с клавиатуры
let keyboard (n: int) : string list =
    [ 
        for i in 1 .. n do
            printf "Введите элемент списка: "
            yield Console.ReadLine()
    ]

// Функция для генерации списка строк случайным образом
let genrandom (n: int) : string list =
    let rnd = new Random()
    [ 
        for i in 1 .. n do
            let length = rnd.Next(1, 10)
            let chars = [| for i in 1 .. length -> char (rnd.Next(97, 123)) |]
            yield new String(chars)
    ]

// Реализация функции map 
let rec list_map (f: 'a -> 'b) (lst: 'a list) : 'b list =
    match lst with
    | [] -> []
    | head :: tail -> (f head) :: (list_map f tail)

// Функция для добавления символа в начало строки
let add (c: char) (s: string) : string =
    c.ToString() + s

// Основная функция программы
let main () =
    printfn "Выберите способ генерации списка:"
    printfn "1. Ввод с клавиатуры"
    printfn "2. Генерация случайным образом"
    let option = vvod_s_proverkoy "Ваш выбор: "

    let lst =
        match option with
        | 1 -> 
            let n = vvod_s_proverkoy "Введите кол-во элементов списка: "
            keyboard n
        | 2 -> 
            let n = vvod_s_proverkoy "Введите кол-во элементов списка: "
            genrandom n
        | _ -> 
            printfn "Неверный выбор. Программа завершена."
            []

    if lst <> [] then
        let c = VYVSTR "Введите символ для добавления в начало строк: "
        let charToAdd = if c.Length > 0 then c.[0] else ' '
        let newList = list_map (add charToAdd) lst
        printfn "Исходный список: %A" lst
        printfn "Новый список: %A" newList

// Запуск программы
main ()