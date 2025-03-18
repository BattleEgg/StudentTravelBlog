fetch('Data/travels.json')
    .then(response => response.json())
    .then(data => {
        const list = document.getElementById('travelsList');
        list.className = 'flex-section-list';
        data.forEach(item => {
            const listItem = document.createElement('li'); // Создаем элемент списка
            listItem.className = 'flex-item-list'; // Добавляем класс для стилизации

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
            listItem.appendChild(title);
            listItem.appendChild(description);
            listItem.appendChild(img);
            listItem.appendChild(date);

            // Добавляем элемент списка в ul
            list.appendChild(listItem);
        });
    })
    .catch(error => console.error('Ошибка при загрузке данных:', error));
