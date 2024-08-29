document.addEventListener('DOMContentLoaded', () => {
    const todoInput = document.getElementById('todoInput');
    const addButton = document.getElementById('addButton');
    const todoList = document.getElementById('todoList');

    addButton.addEventListener('click', addTodo);
    todoInput.addEventListener('keypress', (e) => {
        if (e.key === 'Enter') {
            addTodo();
        }
    });

    function addTodo() {
        const todoText = todoInput.value.trim();
        if (todoText !== '') {
            createTodoElement(todoText);
            todoInput.value = '';
        }
    }

    function createTodoElement(text) {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${text}</span>
            <div>
                <button class="edit-btn">Düzenle</button>
                <button class="delete-btn">Sil</button>
            </div>
        `;
        todoList.appendChild(li);

        const span = li.querySelector('span');
        span.addEventListener('click', (e) => {
            li.classList.toggle('completed');
        });

        li.querySelector('.delete-btn').addEventListener('click', (e) => {
            e.stopPropagation();
            todoList.removeChild(li);
        });

        li.querySelector('.edit-btn').addEventListener('click', (e) => {
            e.stopPropagation();
            const newText = prompt('Görevi düzenle:', span.textContent);
            if (newText !== null && newText.trim() !== '') {
                span.textContent = newText.trim();
            }
        });
    }
});