import React, { useState } from "react";
import styled, { ThemeProvider } from "styled-components";

const lightTheme = { background: "#ffffff", color: "#000000" };
const darkTheme = { background: "#121212", color: "#ffffff" };

const Container = styled.div`
  background: ${(props) => props.theme.background};
  color: ${(props) => props.theme.color};
  min-height: 100vh;
  padding: 20px;
`;

const ThemeToggle = ({ children }) => {
  const [theme, setTheme] = useState(lightTheme);

  return (
    <ThemeProvider theme={theme}>
      <Container>
        <button
          onClick={() =>
            setTheme(theme === lightTheme ? darkTheme : lightTheme)
          }
          style={{ marginBottom: "20px" }}
        >
          Toggle Theme
        </button>
        {children}
      </Container>
    </ThemeProvider>
  );
};

export default ThemeToggle;
