(() => {
  const toggle = document.querySelector("[data-nav-toggle]");
  const nav = document.querySelector("[data-nav]");

  if (toggle && nav) {
    toggle.addEventListener("click", () => {
      const open = nav.classList.toggle("is-open");
      toggle.setAttribute("aria-expanded", open ? "true" : "false");
    });
  }

  const path = (window.location.pathname.replace(/\/$/, "") || "/").toLowerCase();
  document.querySelectorAll(".rail-nav a").forEach((link) => {
    const href = (link.getAttribute("href") || "").toLowerCase();
    if (!href.startsWith("#") && (href === path || (path === "/" && href.endsWith("/index")))) {
      link.classList.add("active");
    }
  });

  const sections = [...document.querySelectorAll("main section[id]")];
  const hashLinks = [...document.querySelectorAll('.rail-nav a[href^="#"]')];
  if (sections.length && hashLinks.length && "IntersectionObserver" in window) {
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (!entry.isIntersecting) return;
          hashLinks.forEach((link) => {
            link.classList.toggle("active", link.getAttribute("href") === `#${entry.target.id}`);
          });
        });
      },
      { rootMargin: "-20% 0px -55% 0px", threshold: 0.1 }
    );
    sections.forEach((section) => observer.observe(section));
  }
})();
