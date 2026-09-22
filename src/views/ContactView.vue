<template ate>
  <main class="contact-page">
    <section class="contact-card">
      <p class="eyebrow">Contact</p>
      <h1>Neem contact op</h1>
      <p class="intro">Heb je vragen of wil je iets bespreken? Stuur gerust een bericht.</p>

      <div class="info">
        <p><strong>Email:</strong> hello@example.com</p>
        <p><strong>Telefoon:</strong> +31 6 123 456 78</p>
      </div>

      <a class="button" href="mailto:hello@example.com">Mail ons</a>
    </section>
  </main>
</template>

<style scoped>
.contact-page {
  min-height: 80vh;
  display: grid;
  place-items: center;
  padding: 2rem;
  background: #f5f5f5;
}

.contact-card {
  max-width: 480px;
  width: 100%;
  background: white;
  border-radius: 16px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.08);
  padding: 2rem;
}

.eyebrow {
  margin: 0 0 0.5rem;
  font-size: 0.8rem;
  letter-spacing: 0.08em;
  text-transform: uppercase;
  color: #666;
}

h1 {
  margin: 0;
  font-size: 2rem;
  color: #1f2937;
}

.intro {
  margin: 1rem 0 1.5rem;
  color: #4b5563;
  line-height: 1.6;
}

.info {
  margin-bottom: 1.5rem;
  color: #1f2937;
}

.info p {
  margin: 0.4rem 0;
}

.button {
  display: inline-block;
  padding: 0.85rem 1.2rem;
  border-radius: 10px;
  background: #111827;
  color: white;
  text-decoration: none;
  font-weight: 600;
}
</style>
