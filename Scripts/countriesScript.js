// Загружаем JSON-файл
fetch('Data/countries.json')
    .then(response => response.json())
    .then(data => {
        const list = document.getElementById('countriesList');
        list.className = 'flex-section-list';
        data.forEach(item => {
            const itemDiv = document.createElement('div'); // Создаем контейнер для элемента
            itemDiv.className = 'flex-item-list'; // Добавляем класс для стилизации

            const title = document.createElement('h3'); // Создаем заголовок
            title.textContent = item.title; // Устанавливаем текст заголовка

            const description = document.createElement('h5');
            description.textContent = item.description; 

            const img = document.createElement('img'); // Создаем элемент изображения
            img.src = item.image; // Устанавливаем путь к изображению
            img.alt = item.title; // Устанавливаем альтернативный текст

            const date = document.createElement('p'); // Создаем элемент для даты
            date.textContent = item.date; // Устанавливаем текст даты

            // Добавляем элементы в контейнер
            itemDiv.appendChild(title);
            itemDiv.appendChild(description);
            itemDiv.appendChild(img);
            itemDiv.appendChild(date);

            // Добавляем контейнер в список
            list.appendChild(itemDiv);
        });
    })
    .catch(error => console.error('Ошибка при загрузке данных:', error));
