"use client"

import type React from "react"
import { useState } from "react"
import { Link, useNavigate } from "react-router-dom"

const RegistrationPage = () => {
  const [formData, setFormData] = useState({
    felhasznaloNev: "",
    teljesNev: "",
    email: "",
    password: "",
  })
  const [error, setError] = useState("")
  const [success, setSuccess] = useState("")
  const navigate = useNavigate()

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value })
  }

  // Function to generate a random salt
  const generateSalt = () => {
    const array = new Uint8Array(16)
    crypto.getRandomValues(array)
    return Array.from(array, (byte) => byte.toString(16).padStart(2, "0")).join("")
  }

  // Function to hash the password with salt
  const hashPassword = async (password: string, salt: string) => {
    const encoder = new TextEncoder()
    const data = encoder.encode(password + salt)
    const hashBuffer = await crypto.subtle.digest("SHA-256", data)
    const hashArray = Array.from(new Uint8Array(hashBuffer))
    return hashArray.map((byte) => byte.toString(16).padStart(2, "0")).join("")
  }

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    setError("")
    setSuccess("")

    try {
      const salt = generateSalt()
      const hash = await hashPassword(formData.password, salt)

      const user = {
        userId: 0,
        felhasznaloNev: formData.felhasznaloNev,
        teljesNev: formData.teljesNev,
        salt: salt,
        hash: hash,
        email: formData.email,
        jogosultsag: 0,
        aktiv: 1,
        regisztracioDatuma: new Date().toISOString(),
        profilKepUtvonal: "",
        timeBalance: 0,
      }

      const response = await fetch("http://your-api-url/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(user),
      })

      if (!response.ok) {
        const errorData = await response.json()
        throw new Error(errorData.message || "Hálózati hiba történt")
      }

      const data = await response.json()
      console.log(data)
      setSuccess("Sikeres regisztráció!")
      setTimeout(() => navigate("/LoginPage"), 2000)
    } catch (error) {
      console.error("Registration error:", error)
      setError(error instanceof Error ? error.message : "Hiba történt a regisztráció során. Kérjük, próbálja újra.")
    }
  }

  return (
    <section className="hero full-screen">
      <h2>Regisztráció</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="felhasznaloNev"
          placeholder="Felhasználónév"
          value={formData.felhasznaloNev}
          onChange={handleChange}
          required
        />
        <br />
        <input
          type="text"
          name="teljesNev"
          placeholder="Teljes név"
          value={formData.teljesNev}
          onChange={handleChange}
          required
        />
        <br />
        <input type="email" name="email" placeholder="Email" value={formData.email} onChange={handleChange} required />
        <br />
        <input
          type="password"
          name="password"
          placeholder="Jelszó"
          value={formData.password}
          onChange={handleChange}
          required
        />
        <br />
        <button type="submit" className="form-button">
          Regisztráció
        </button>
      </form>
      {error && <p className="error-message">{error}</p>}
      {success && <p className="success-message">{success}</p>}
      <p>
        Már van fiókod? <Link to="/LoginPage">Bejelentkezés</Link>
      </p>
      <Link to="/">
        <button className="cta-button">Vissza a kezdőlapra</button>
      </Link>
    </section>
  )
}

export default RegistrationPage

