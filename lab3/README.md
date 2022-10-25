<p>Даний орієнтований граф, у якому можуть бути кратні ребра та петлі. Кожне ребро має вагу, що виражається цілим числом (можливо негативним). 
Гарантується, що цикли негативної ваги відсутні.
Потрібно порахувати довжини найкоротших шляхів від вершини номер 1 до решти вершин.</p>
<p>Вхідні дані</p>
<p>У першому рядку вхідного файлу INPUT.TXT записані цілі числа N і M - кількість вершин та кількість ребер графа (1 ≤ N ≤ 100, 0 ≤ M ≤ 10000). 
У кожному з наступних рядків M записана трійка чисел, що описують ребра: початок ребра, кінець ребра і вага (вага - ціле число від -100 до 100).</p>
<p>Вихідні дані</p>
<p>У вихідний файл OUTPUT.TXT виведіть N чисел – відстані від вершини номер 1 до всіх вершин графа. 
Якщо шляху до відповідної вершини немає, замість довжини шляху виведіть число 30000.</p>
<p>Приклад</p>
<pre>
№	INPUT.TXT	OUTPUT.TXT
 	4 5
        1 2 10
1       2 3 10          0 10 11 30000
        1 3 100
        3 1 -10
        2 3 1	
</pre>