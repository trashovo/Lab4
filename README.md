# Суханов Сергей Лаб-2(ИТ-5) Лабораторная №4 (Вариант 15)

# Задание 1

## Работа с List

### Текст задачи

Определить количество различных элементов списка.

### Алгоритм решения

В классе `ListTasks` реализуется метод `CountDistinct<T>(List<T> list)`.
* Метод создаёт новый пустой список `unique`.
* *Затем он перебирает все элементы входного списка и с помощью метода `Contains()` проверяет их наличие в списке `unique`.
Если элемент встречается впервые, он добавляется.
* Итоговое количество уникальных элементов определяется через свойство `Count` списка `unique`.

### Тестирование
<img width="292" height="202" alt="image" src="https://github.com/user-attachments/assets/c4b8fac6-eaa5-4842-a55b-75790ae9b9c6" />
<br>
<img width="290" height="183" alt="image" src="https://github.com/user-attachments/assets/04eb6bbd-0b5e-4ddb-886c-c8a6f59a30e2" />
<br>
<img width="143" height="53" alt="image" src="https://github.com/user-attachments/assets/409d3ba7-c2b4-46ce-a596-33fb880aedb0" />
<br>
<img width="284" height="162" alt="image" src="https://github.com/user-attachments/assets/99e03481-1459-4ce6-b322-ae35300df7c5" />


# Задание 2

## Работа с LinkedList

### Текст задачи

Если у элемента со значением `E` соседи не равны, заменить их на элемент `F`.

### Алгоритм решения

В классе `ListTasks` реализован метод `ReplaceUnequalNeighbors`, принимающий на вход список `LinkedList<string>`, а также целевое значение `E` и значение для замены `F`.
* Метод использует цикл для прохода по узлам списка, начиная со второго и заканчивая предпоследним. *Если значение текущего узла совпадает с `E`, выполняется проверка значений предыдущего (`current.Previous.Value`) и следующего (`current.Next.Value`) узлов. Если они не равны, ссылки на эти узлы сохраняются во временный список `nodesToReplace`.
* После завершения поиска цикл проходит по временному списку и заменяет значения всех сохраненных узлов на `F`.

### Тестирование
<img width="267" height="242" alt="image" src="https://github.com/user-attachments/assets/e1d8d9d6-8afa-4b22-95ab-ad2b4e552794" />
<br>
<img width="272" height="248" alt="image" src="https://github.com/user-attachments/assets/ec7cd014-effa-43f2-add1-6204dabbffad" />
<br>
<img width="315" height="293" alt="image" src="https://github.com/user-attachments/assets/44fad2d9-0d48-4efd-8270-793fcf69f3c4" />
<br>
<img width="228" height="87" alt="image" src="https://github.com/user-attachments/assets/a521f50d-0ba9-4f5a-b72a-9804bf042141" />
<br>
<img width="246" height="76" alt="image" src="https://github.com/user-attachments/assets/e531813f-e938-47a5-9a33-36217f590501" />

# Задание 3

## Работа с HashSet

### Текст задачи

Дано `N` кооперативов, каждый из которых возделывает определенный набор сельскохозяйственных культур. Необходимо определить культуры:

1. Возделываемые во всех кооперативах.
2. Возделываемые только в некоторых кооперативах.
3. Возделываемые ровно в одном кооперативе.

### Алгоритм решения

В классе `ListTasks` реализован метод `AnalyzeCrops`, принимающий список списков строк (кооперативы и их культуры).
* Метод преобразует список каждого кооператива в `HashSet<string>` для исключения дубликатов внутри одного хозяйства и все встреченные культуры собираются в множество `allUniqueCrops` с помощью метода объединения `UnionWith`.
* С помощью пересечения `IntersectWith` определяются культуры, которые есть во всех хозяйствах сразу, и записываются в `inAll`.
* для оставшихся культур из `allUniqueCrops` считается, в скольких хозяйствах они встречаются (`count`). Если больше чем в одном — культура идёт в `inSome`, если только в одном — в `inOne`.

### Тестирование
<img width="479" height="249" alt="image" src="https://github.com/user-attachments/assets/269ed3b9-7cde-4e94-9b0e-8396b62d060e" />
<br>
<img width="476" height="235" alt="image" src="https://github.com/user-attachments/assets/2a5dc2b8-df02-4e1b-8a3b-ecf8eab343be" />
<br>
<img width="453" height="209" alt="image" src="https://github.com/user-attachments/assets/8dbbbe91-dee4-4f6c-8969-c1b449a6034b" />
<br>
<img width="411" height="95" alt="image" src="https://github.com/user-attachments/assets/7c73aab2-143a-4815-aeb4-5d37d058d82a" />
<br>
<img width="439" height="76" alt="image" src="https://github.com/user-attachments/assets/2d19c889-d896-41d2-bdeb-a36c7ca467c7" />

# Задание 4

## Работа с HashSet

### Текст задачи

Найти символы, присутствующие в каждом слове введенного текста на русском языке.

### Алгоритм решения

В классе `ListTasks` метод `FindCommonChars` принимает исходную строку текста.
* Текст делится на слова с помощью Split, разделителями служат пробелы и знаки препинания.
* Каждое слово приводится к нижнему регистру и преобразуется в множество символов `HashSet<char>`.
* Берётся множество первого слова, которое поочерёдно пересекается со всеми остальными словами через `ectWith`. Оставшиеся общие символы записываются в итоговый список `result`.

### Тестирование
<img width="523" height="57" alt="image" src="https://github.com/user-attachments/assets/97b20872-d96a-4838-8f13-c2bb1dad8ed7" />
<br>
<img width="507" height="65" alt="image" src="https://github.com/user-attachments/assets/f3b2de0d-124a-4c7b-9045-d63e4ee0122f" />
<br>
<img width="511" height="57" alt="image" src="https://github.com/user-attachments/assets/50d757ef-ed0c-4512-9a62-f2118f923659" />
<br>
<img width="299" height="49" alt="image" src="https://github.com/user-attachments/assets/2c5e183c-5e3a-4023-a72a-8266ea026140" />


# Задание 5

## Пользовательские классы и перегрузка операторов

### Текст задачи

Создать класс `Money` для рублей и копеек. Добавить метод сравнения двух сумм `IsEqual`, сделать перегрузку для добавления и вычитания одной копейки (++ и --), настроить приведение к числам (получение только рублей или копеек), а также вычитание целого числа копеек из суммы и наоборот.

### Алгоритм решения

Создан класс `Money` с закрытыми полями `_rubles` (uint) и `_kopeks` (byte). В свойствах настроен автоматический перевод: если копеек становится 100 или больше.
Для удобства добавлены методы `TotalKopecks` и `FromTotalKopecks`, позволяющие переводить всю сумму в копейки и обратно.
Реализованы перегрузки:

* Операторы `++` и `--` добавляют или вынимают одну копейку.
* Неявное приведение `implicit operator uint` возвращает количество рублей (`_rubles`).
* Явное приведение `explicit operator double` возвращает копейки, в виде десятичной дроби.
* Бинарный оператор `-` перегружен для двух случаев (`Money - int` и `int - Money`), вычитаются копейки, а если результат уходит в минус, выдается ошибка.

### Тестирование
<img width="468" height="818" alt="image" src="https://github.com/user-attachments/assets/5499ad1b-f49f-4761-b68a-4d0ea3cd5a98" />
<br>
<img width="531" height="781" alt="image" src="https://github.com/user-attachments/assets/b484a7fd-b253-48d6-b068-49a1aca2aaa4" />
<br>
<img width="369" height="225" alt="image" src="https://github.com/user-attachments/assets/fda3d902-00f5-4132-8057-be9330331ee4" />
