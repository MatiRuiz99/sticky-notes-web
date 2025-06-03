import React, { useEffect, useState } from "react";

const UserNotes = ({ userId }) => {
  const [notes, setNotes] = useState([]);
  userId = 1;

  useEffect(() => {
    const fetchNotes = async () => {
      try {
        const response = await fetch(`https://stickynotesapi-fyhug5cgb8cqcgd7.canadacentral-01.azurewebsites.net/api/Note/GetNotes/${userId}`);
        if (!response.ok) {
          throw new Error("Error al obtener las notas");
        }
        const data = await response.json();
        setNotes(data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchNotes();
  }, [userId]);

  return (
    <div>
      <h2>Notas del Usuario {userId}</h2>
      <ul>
        {notes.map((note) => (
          <li key={note.id}>
            <strong>Categoría ID:</strong> {note.categoryId} <br />
            <strong>Texto:</strong> {note.text}
          </li>
        ))}
      </ul>
    </div>
  );
};


export default UserNotes;
