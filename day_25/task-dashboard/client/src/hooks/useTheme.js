// src/hooks/useTheme.js
import { useState } from "react";

const lightTheme = { background: "#fff", color: "#000" };
const darkTheme = { background: "#121212", color: "#fff" };

const useTheme = () => {
  const [theme, setTheme] = useState(lightTheme);

  const toggleTheme = () => {
    setTheme((prev) => (prev === lightTheme ? darkTheme : lightTheme));
  };

  return { theme, toggleTheme };
};

export default useTheme;
