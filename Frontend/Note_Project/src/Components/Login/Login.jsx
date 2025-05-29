import { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { Button, Modal, Form, Alert } from 'react-bootstrap';

function LoginRegister() {
  const [show, setShow] = useState(false);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isLogin, setIsLogin] = useState(true);
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    
    if (!email || !password) {
      setError('Please fill in all fields');
      return;
    }
  
    try {
      const endpoint = isLogin ? 'https://stickynotesapi-fyhug5cgb8cqcgd7.canadacentral-01.azurewebsites.net/api/User/login' : 'https://stickynotesapi-fyhug5cgb8cqcgd7.canadacentral-01.azurewebsites.net/api/User/register';
      const response = await fetch(endpoint, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password }),
      });
  
      const data = await response.json();
  
      if (!response.ok) {
        throw new Error(data.message || 'Authentication failed');
      }
  
      // Successful authentication
      console.log('Success:', data);
      
      // Store the token if your API returns one
      if (data.token) {
        localStorage.setItem('token', data.token);
      }
  
      // Reset form and close modal
      setEmail('');
      setPassword('');
      setShow(false);
      
      // Optional: Redirect or update app state
      // window.location.href = '/dashboard';
  
    } catch (err) {
      setError(err.message || 'Something went wrong');
    }
  };
  
  return (
    <>
      <Button variant="primary" onClick={() => setShow(true)}>
        Login
      </Button>

      <Modal show={show} onHide={() => setShow(false)} centered>
        <Modal.Header closeButton>
          <Modal.Title>{isLogin ? 'Login' : 'Register'}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {error && <Alert variant="danger">{error}</Alert>}
          <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3">
              <Form.Label>Email address</Form.Label>
              <Form.Control
                type="email"
                placeholder="Enter email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Password</Form.Label>
              <Form.Control
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </Form.Group>

            <div className="d-grid gap-2">
              <Button variant="primary" type="submit">
                {isLogin ? 'Login' : 'Register'}
              </Button>
            </div>
          </Form>
        </Modal.Body>
        <Modal.Footer className="justify-content-center">
          <Button variant="link" onClick={() => setIsLogin(!isLogin)}>
            {isLogin ? 'Need an account? Register' : 'Already have an account? Login'}
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default LoginRegister;