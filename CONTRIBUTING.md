# Як долучитися до проєкту (Contributing)

Ми раді, що ви хочете допомогти покращити **Typing Speed Test**! 
Ось інструкція, як це зробити максимально ефективно.

## Алгоритм роботи

1.  **Fork** цей репозиторій собі в акаунт.
2.  Склонуйте форк на локальну машину:
    ```bash
    git clone [https://github.com/ВАШ_НІК/TypingSpeedTest.git](https://github.com/ВАШ_НІК/TypingSpeedTest.git)
    ```
3.  **Створіть нову гілку** для вашої зміни:
    ```bash
    git checkout -b feature/new-cool-feature
    # або для виправлення помилок
    git checkout -b fix/bug-fix-name
    ```
4.  Внесіть зміни та **закомітьте** їх:
    ```bash
    git add .
    git commit -m "Опис того, що ви змінили"
    ```
5.  Зробіть **Push** у свій форк:
    ```bash
    git push origin feature/new-cool-feature
    ```
6.  Створіть **Pull Request (PR)** на GitHub з вашого форку в цей репозиторій.

## Правила коду

* Використовуйте зрозумілі назви змінних.
* Код має бути відформатований.
* Коміти мають бути атомарними (одна логічна зміна — один коміт).
