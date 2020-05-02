<h1>Shooting-Game</h1>

<p>Echipa 18: 
<ul>
    <li>Pop Denisa - 343 </li>
    <li>Chitescu Narcis - 343 </li>
    <li>Paraschiv Andrei - 334 </li>
</ul></p>
<p>
<h3>Prezentarea jocului:</h3>
Am realizat un joc 3d - first person, pornind de la modelul pus la dispozitie de FPS-microgames. Caracterul principal trebuie sa exploreze toate camerele arenei in cautarea inamicilor. Exista doua tipuri de oponenti: primul tip - botul- este reprezentat de figurine care detecteaza playerul indata ce intra in raza lor de actiune sau initiaza atacul, dupa care il urmaresc si trag cate un glont la 0.5 secunde; cel de-al doilea tip - tureta - este reprezentat de inamici statici, dar mult mai puternici care se afla in camera finala. Acestia lanseaza atacul cand playerul a patruns in sfera vizuala si trag automat.
</p>
<p>
Ca recompense, in unele dintre camere, dupa uciderea botilor, apar arme mai puternice care pot fi ridicate. Playerul poate avea cel mult 3 arme si le poate schimba intre ele folosind tastele 1, 2 sau 3. Mai mult, dupa uciderea unor boti, in urma acestora raman zone de heal pe care le poti folosi pentru a regenera cate 20 healing-points pierdute in luptele anterioare. 
</p><p>
Exista doua moduri de a trage, cel normal cu click stanga, si unul cu scope - click dreapta, mai stabil si usor de controlat, utilizat preponderent pentru impuscarea inamicilor aflati la distanta mai mare. Pe masura ce se avanseaza in joc si se elimina oponenti, scorul creste. In scena finala, dupa sfarsitul jocului - fie cand toti inamicii au fost ucisi, fie cand caracterul principal si-a pierdut viata -  se afiseaza punctajul acumulat.
</p><p>
In rubrica high-scores se afla cele mai mari 5 punctaje. 
</p>
<h3>Organizare:</h3> 
<p>
In urma a doua intalniri, ne-am hotarat asupra temei si am conturat detaliile jocului, organizandu-le sub forma de task-uri. 
</p><p>
Pentru inceput, ne-am familiarizat cu lucrurile de baza in Unity cu ajutorul unor tutoriale**.
</p><p>
Am descoperit FPS-microgames si l-am adoptat ca sablon in proiectul nostru, am dezvoltat arena de joc prin adaugare de noi inamici, noi arme si noi camere de lupta, customizarea inamicilor si abilitatilor playerului, schimbarea cromaticii jocului si detaliilor.
</p><p>
Odata puse la punct actiunile principale din joc (deplasari, abilitatile inamicilor, tipurile de shooting si de arme), am trecut la crearea unui sistem de acumulare a punctelor. Jucatorul poate acumula pe parcus puncte, prin atacarea si eliminarea inamicilor si prin strangerea de health dar poate sa si piarda atunci cand este lovit. La final acestora li se mai adauga 100 de puncte daca castiga, sau se scad 30 daca pierde. Punctajul este afisat in timpul jocului alaturi de health.
</p><p>
Partea finala a constat in finisarea detaliilor si in dezvoltarea unei rubrici de high-scores, salvate sub forma de obiecte de tip json intr-un fisier text pe disk, fiecare continand, stocate intr-un array, cele mai mari 5 scoruri.
Am creat o metoda de vizualizare a acestui istoric ierarhic, sub forma de nou layout, ce poate fi accesat din rubrica ‘high-scores’ din meniul principal. 
</p><p>  

Jocul a fost realizat in Unity, repository-ul se afla aici: https://github.com/spopawdodo/Shooter-Game 
</p><p>

<h3>Referinte:</h3> 

<h4>**Tutoriale unity:<h4>
<ul>
<li>https://www.youtube.com/watch?v=XDAYS-qYe6Y</li>
<li>https://www.youtube.com/watch?v=jE3ZJ_tCGTo</li>
<li>https://www.youtube.com/watch?v=j48LtUkZRjU&list=PLPV2KyIb3jR5QFsefuO2RlAgWEz6EvVi6</li>
</ul>

<h4>Tutoriale scor:</h4>
<ul>
<li>https://www.youtube.com/watch?v=vZU51tbgMXk</li>
<li>https://www.youtube.com/watch?v=NJuEsJZfHIU</li>
</ul>

<h4>FPS migrogames:</h4> 
<ul>
<li>https://assetstore.unity.com/packages/templates/fps-microgame-156015</li>
</ul>
</p>




