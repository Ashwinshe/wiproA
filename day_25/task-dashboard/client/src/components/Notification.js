import React, { useContext } from "react";
import { TaskContext } from "../context/TaskContext";

const Notification = () => {
  const { notifications } = useContext(TaskContext);

  return (
    <div>
      {notifications.map((note, index) => (
        <div
          key={index}
          style={{
            background: "#fffae0",
            padding: "5px 10px",
            marginBottom: "5px",
            border: "1px solid #f0e68c",
            borderRadius: "4px",
          }}
        >
          {note}
        </div>
      ))}
    </div>
  );
};

export default Notification;
